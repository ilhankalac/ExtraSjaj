import React, { Component } from 'react';
import { Button, Table } from 'reactstrap';
import axios from 'axios';
import { browserHistory } from 'react-router';



export class Musterije extends Component {

    static displayName = Musterije.name;


    routeChange() {
        browserHistory.push('/CreateMusterija');
    }
   

    state = {
        musterijeNiz : [],
        loading : false,

    }

    componentWillMount() {
        axios.get("api/Musterijas").then((response) => {
            this.setState({
                musterijeNiz: response.data
            });
        });
    }
    

    static renderMusterijasTable(musterijeNiz) {
        return (
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
                    {musterijeNiz.map(item =>
                        <tr key={item.Id}>
                            <td>{item.ime}</td>
                            <td>{item.prezime}</td>
                            <td>{item.brojTelefona}</td>
                            <td>{item.adresa}</td>
                            <td>{item.vrijemeKreiranjaMusterije}</td>
                            <td>
                                <Button color="success" size="sm" className="mr-2">Edit </Button>
                                <Button color="danger" size="sm" className="mr-2"> Obriši </Button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {

        //refreshing data from database on page redirections to this page
        this.componentWillMount();

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Musterije.renderMusterijasTable(this.state.musterijeNiz);

        return (
            <div>
                <center> <h1>Lista mušterija</h1> </center>
                <Button color="success" className="mr-3" onClick={this.routeChange}> Kreiraj mušteriju </Button> 
                {contents}
            </div>
        );
    }
}
