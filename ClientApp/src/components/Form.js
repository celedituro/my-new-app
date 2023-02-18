import axios from "axios";
import React from "react";

const Form = () => {
    // eslint-disable-next-line no-unused-vars
    const [formValue, setFormValue] = React.useState({
        name: '',
        dateOfBirth: ''
      });
    
    const handleChange = (event) => {
        var key = event.target.id;
        var value = event.target.value
        formValue[key] = value;
    }

    const handlePost = async () => {      
        try {
            const response = await axios({
                method: "post",
                url: "https://localhost:44425/people",
                data: {
                    name: formValue.name,
                    dateOfBirth: formValue.dateOfBirth,
                    category: {
                        name: null
                    }
                },
                headers: { "Content-Type": "application/json" },
            });
            console.log(response.data);
        } catch(error) {
            console.log(error)
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
                                    </div>
                                </div>
                                <button type="submit" className="btn btn-primary" onClick={handlePost}>Enviar</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
    );
}

export default Form;