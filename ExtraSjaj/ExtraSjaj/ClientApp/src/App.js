import React, { Component } from 'react';
import { Route, Router, browserHistory } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { axios } from 'axios';
import { Musterije } from './components/Musterije';
import { CreateMusterija } from './components/Musterija/CreateMusterija';
import { EditMusterija } from './components/Musterija/EditMusterija';
import { Register } from './components/Register';
import { Login } from './components/Login';
import MusterijaTable from './components/MusterijaTable';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Router history={browserHistory}>
                    <Route exact path='/' component={Home} />
                    <Route path='/counter' component={Counter} />
                    <Route path='/fetch-data' component={FetchData} />
                    <Route path='/Musterije' component={Musterije} />
                    <Route path='/CreateMusterija' component={CreateMusterija} />
                    <Route path='/EditMusterija' component={EditMusterija} />
                    <Route path='/MusterijaTable' component={MusterijaTable} />
                    <Route path='/Register' component={Register} />
                    <Route path='/Login' component={Login} />
                </Router>
            </Layout>
        );
    }
}