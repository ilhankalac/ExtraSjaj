import React, { Component } from 'react';
import { Button, Table } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';



export class Musterije extends Component {

    static displayName = Musterije.name;


    routeChangeToCreate() {

        browserHistory.push('/CreateMusterija');
    }

    routeChangeToEdit(Musterija) {

        browserHistory.push({ pathname: '/EditMusterija', state: {Edit: Musterija } });
    }


    state = {
        musterijeNiz: [],
        loading: false,

    }

    componentWillMount() {
        axios.get("api/Musterijas").then((response) => {
            this.setState({
                musterijeNiz: response.data
            });
        });
    }

    deleteMusterija(id) {

        axios.delete("api/Musterijas/" + id);

    }

    render() {
        //refreshing data from database on page redirections to this page
        this.componentWillMount();

        let tableData =
            this.state.musterijeNiz.map(item =>
                <tr key={item.id}>
                    <td>{item.ime}</td>
                    <td>{item.prezime}</td>
                    <td>{item.brojTelefona}</td>
                    <td>{item.adresa}</td>
                    <td>{item.vrijemeKreiranjaMusterije}</td>
                    <td>
                        <Button color="success" size="sm" className="mr-2" onClick={this.routeChangeToEdit.bind(this, item)}>Edit </Button>
                        <Button color="danger" size="sm" className="mr-2" onClick={this.deleteMusterija.bind(this, item.id)}> Obriši </Button>
                    </td>
                </tr>
            );

        return (
            <div>
                <center> <h1>Lista mušterija</h1> </center>
                <Button color="success" className="mr-3" onClick={this.routeChangeToCreate}> Kreiraj mušteriju </Button>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Ime</th>
                            <th>Prezime</th>
                            <th>Broj telefona</th>
                            <th>Adresa</th>
                            <th>Vrijeme kreiranja mušterije</th>
                            <th>Akcije </th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableData}
                    </tbody>
                </table>
            </div>
        );
    }
}
