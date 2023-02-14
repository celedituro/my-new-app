import { useEffect, useState} from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import '../FetchData.css';

const FetchData = () => {
    const [search, setSearch] = useState("");
    const [people, setPeople] = useState([]);
    const [peopleTable, setPeopleTable] = useState([]);

    const getPeople = async () => {
        try {
            const response = await axios.get("https://localhost:44425/people");
            setPeople(response.data);
            setPeopleTable(response.data);
            console.log(response.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {
        getPeople();
    }, [])

    const handleChange = e => {
        console.log("Búsqueda:", e.target.value);
        setSearch(e.target.value);
        filter(e.target.value);
    }

    const filter = (query) => {
        // eslint-disable-next-line array-callback-return
        var searchResult = peopleTable.filter((element) => {
            console.log('query:', query);
            console.log('element:', element);
            var elementName = element.name.toString().toLowerCase();
            console.log('elementName:', elementName);
            var elementDateOfBirth = element.dateOfBirth.toString();
            console.log('elementDate:', elementDateOfBirth);
            if(elementName.includes(query.toLowerCase())
            || elementDateOfBirth.includes(query)){
                return element;
            } 
        });
        setPeople(searchResult);
    }

    return (
        <div className="App">
                <form className="containerSearch">
                    <input
                        className="form-control inputSearch"
                        value={search}
                        placeholder="Búsqueda por Nombre o Fecha de nacimiento"
                        onChange={handleChange}
                    />
                    <button type="submit" className="btn btn-success buttonSearch">
                        <FontAwesomeIcon icon={faSearch}/>
                    </button>
                </form>
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

