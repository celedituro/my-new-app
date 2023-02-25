import { useEffect, useState} from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import '../styles/Home.css';

const Home = () => {
    const [people, setPeople] = useState([]);

    const getPeople = async () => {
        try {
            const response = await axios.get("https://localhost:44425/people/all");
            setPeople(response.data);
            console.log(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {
        getPeople();
    }, [])

    const handleClean = () => {
        getPeople();
    }

    const handleSearch = async (search) => {
        try {
            const response = await axios.get('https://localhost:44425/people', { params: { word: search } });
            setPeople(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    const handleChange = e => {
        const word = e.target.value;
        handleSearch(word);
        if (word.length === 0) {
            handleClean();
        }
    }

    return (
        <div>
            <div className="containerSearch">
                <input
                    className="form-control inputSearch"
                    placeholder="Búsqueda por Nombre o Apellido"
                    onChange={handleChange}
                />
                <button type="submit" className="btn btn-primary buttonClean" onClick={handleClean}>Clear</button>
            </div>
            <div className="table-responsive">
                <table className="table table-striped" aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Fecha de nacimiento</th>
                        <th>Categoría</th>
                        </tr>
                    </thead>
                    <tbody>
                        {people.map(person =>
                        <tr key={person.id}>
                            <td>{person.id}</td>
                            <td>{person.firstName}</td>
                            <td>{person.lastName}</td>
                            <td>{person.dateOfBirth}</td>
                            <td>{person.categoryName}</td>
                        </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>
      );
}

export default Home;

