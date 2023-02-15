import { useEffect, useState} from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEraser } from '@fortawesome/free-solid-svg-icons';
import '../styles/FetchData.css';

const FetchData = () => {
    const [people, setPeople] = useState([]);

    const getPeople = async () => {
        try {
            const response = await axios.get("https://localhost:44425/people");
            setPeople(response.data);
            console.log(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {
        getPeople();
    }, [])

    const handleChange = e => {
        handleSearch(e.target.value);
    }

    const handleSearch = async (search) => {
        try {
            const response = await axios.get('https://localhost:44425/people/search', { params: { word: search } });
            setPeople(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    const handleClean = () => {
        getPeople();
    }

    return (
        <div>
            <div className="containerSearch">
                <input
                    className="form-control inputSearch"
                    placeholder="Búsqueda por Nombre o Categoría"
                    onChange={handleChange}
                />
                <button type="submit" className="btn btn-primary buttonClean" onClick={handleClean}>
                    <FontAwesomeIcon icon={faEraser} />
                </button>
            </div>
            <div className="table-responsive">
                <table className="table table-striped" aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Fecha de nacimiento</th>
                        <th>Categoria</th>
                        </tr>
                    </thead>
                    <tbody>
                        {people.map(person =>
                        <tr key={person.id}>
                            <td>{person.id}</td>
                            <td>{person.name}</td>
                            <td>{person.dateOfBirth}</td>
                            <td>{person.category}</td>
                        </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>
      );
}

export default FetchData;

