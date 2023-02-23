import axios from "axios";
import React from "react";

const MIN_LENGTH_NAME = 3;
const MAX_LENGTH_NAME = 30;
const NAME_KEY = 'nombre';

const Form = () => {
    // eslint-disable-next-line no-unused-vars
    const [formValue, setFormValue] = React.useState({
        name: '',
        dateOfBirth: ''
    });
    const [nameError, setNameError] = React.useState('');
    const [dateOfBirthError, setDateOfBirthError] = React.useState('');
    const [isValid, setIsValid] = React.useState(true);

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
        for (const i in errors) {
            var err = errors[i];
            if (err.includes(NAME_KEY)) {
                setNameError(err);
            } else {
                setDateOfBirthError(err);
            }
            setIsValid(false);
        }
    }

    const validateName = () => {
        if (isLengthValid(formValue.name.length)) {
            setNameError('Ingresar entre 3 y 30 letras');
            setIsValid(false);
        }
        if (hasNumber(formValue.name)) {
            setNameError('No ingresar números');
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
                        </div>
                    </div>
                </div>
            </div>
    );
}

export default Form;