import React, { Component } from 'react';

export class Musterije extends Component {

    static displayName = Musterije.name;

    constructor(props) {
        super(props);
        this.state = { musterijeNiz: [], loading: true };

        fetch('api/Musterijas')
            .then(response => response.json())
            .then(data => {
                this.setState({ musterijeNiz: data, loading: false });
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
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Musterije.renderMusterijasTable(this.state.musterijeNiz);

        return (
            <div>
                <h1>Lista mušterija</h1>
                {contents}
            </div>
        );
    }
}
