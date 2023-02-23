import axios from "axios";
import React from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import CONSTANTS from "../utils/Constants";

const MIN_LENGTH_NAME = 3;
const MAX_LENGTH_NAME = 30;
const EMPTY = "";
const NAME_KEY = "Name";
const ERRORS = [CONSTANTS.INVALID_LENGTH_NAME, CONSTANTS.INVALID_NAME_WITH_NUMBERS, CONSTANTS.INVALID_FUTURE_DATE_OF_BIRTH];

const Form = () => {
    // eslint-disable-next-line no-unused-vars
    const [formValue, setFormValue] = React.useState({
        name: '',
        dateOfBirth: ''
    });
    const [nameError, setNameError] = React.useState('');
    const [dateOfBirthError, setDateOfBirthError] = React.useState('');
    const [isValid, setIsValid] = React.useState(true);
    const [show, setShow] = React.useState(false);

    React.useEffect(() => {
        setNameError('');
        setDateOfBirthError('');
    }, ]);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleChange = (event) => {
        var key = event.target.id;
        var value = event.target.value
        formValue[key] = value;
    }

    function hasNumber(string) {
        return /\d/.test(string);
    }

    function isLengthValid(nameLength) {
        return (nameLength < MIN_LENGTH_NAME || nameLength > MAX_LENGTH_NAME);
    }

    function showErrors(errors) {
        for (const key in errors) {
            const err = errors[key][0];
            if (ERRORS.includes(err)) {
                if (key === NAME_KEY) {
                    if (nameError === EMPTY) {
                        setNameError(err);
                    }
                } else {
                    if (dateOfBirthError === EMPTY) {
                        setDateOfBirthError(err);
                    }
                }
                setIsValid(false);
            }
        }
    }

    const validateName = () => {
        if (isLengthValid(formValue.name.length)) {
            setNameError(CONSTANTS.INVALID_LENGTH_NAME);
            setIsValid(false);
        }
        if (hasNumber(formValue.name)) {
            setNameError(CONSTANTS.INVALID_NAME_WITH_NUMBERS);
            setIsValid(false);
        }
    }

    const handleSubmit = async (e) => {      
        try {
            validateName();
            if (isValid) {
                e.preventDefault();
                const response = await axios({
                    method: "post",
                    url: "https://localhost:44425/people",
                    data: {
                        name: formValue.name,
                        dateOfBirth: formValue.dateOfBirth,
                    },
                    headers: { "Content-Type": "application/json" },
                });
                console.log(response.data);
                handleShow();
            }
        } catch(error) {
            const errors = error.response.data.errors;
            showErrors(errors);
        }
    };

    return (
            <div className="row justify-content-center align-items-center">
                <div className="col-12 col-lg-9 col-7">
                    <div className="card">
                        <div className="card-body p-4 p-md-5">
                            <h4 className="mb-4 pb-2 pb-md-0 mb-md-5">Formulario de Registración</h4>
                            <form>
                                <div className="row">
                                    <div className="col-md-6 mb-4 align-items-center">
                                        <div className="form-outline">
                                            <label className="form-label" htmlFor="name">Nombre</label>
                                            <input 
                                                type="text" 
                                                className="form-control" 
                                                id="name" 
                                                placeholder="Ingrese su nombre" 
                                                onChange={handleChange}
                                                required/>
                                        </div>
                                        <div>
                                            <p className="text-danger">{nameError}</p>
                                        </div>
                                    </div>
                                </div>

                                <div className="row">
                                    <div className="col-md-6 mb-4 align-items-center">
                                        <div className="form-outline">
                                            <label htmlFor="dateOfBirth" className="form-label">Fecha de nacimiento</label>
                                            <div className="input-with-post-icon">
                                                <input 
                                                    type="date" 
                                                    id="dateOfBirth" 
                                                    className="form-control" 
                                                    onChange={handleChange} 
                                                    required/>
                                            </div>
                                        </div>
                                        <div>
                                            <p className="text-danger">{dateOfBirthError}</p>
                                        </div>
                                    </div>
                                </div>
                                <button type="submit" className="btn btn-primary" onClick={handleSubmit}>Enviar</button>
                            </form>
                            <Modal show={show} onHide={handleClose}>
                                <Modal.Header closeButton>
                                    <Modal.Title>Información</Modal.Title>
                                </Modal.Header>
                                <Modal.Body>Se ha agregado a {formValue.name} éxitosamente</Modal.Body>
                                <Modal.Footer>
                                    <Button variant="secondary" onClick={handleClose}>
                                        Cerrar
                                    </Button>
                                </Modal.Footer>
                            </Modal>
                        </div>
                    </div>
                </div>
            </div>
    );
}

export default Form;