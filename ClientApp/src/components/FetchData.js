import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { people: [], loading: true };
  }

  componentDidMount() {
    this.populatePeopleData();
  }

  static renderPeopleTable(people) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>DateOfBirth</th>
            <th>Category</th>
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
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderPeopleTable(this.state.people);

    return (
      <div>
        <h1 id="tableLabel">People Table</h1>
        {contents}
      </div>
    );
  }

  async populatePeopleData() {
    const response = await fetch('person');
    const data = await response.json();
    this.setState({ people: data, loading: false });
  }
}