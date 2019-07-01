import React, { Component } from 'react';
import { Button } from 'reactstrap'
import { LineChart, Line, CartesianGrid, XAxis, YAxis } from 'recharts';
import axios from 'axios';
import { RoleAwareComponent } from 'react-router-role-authorization';
import { NotFound } from './NotFound';
import Cookies from 'js-cookie';



export class Statistics extends RoleAwareComponent {
    constructor(props) {
        super(props);

        this.allowedRoles = '1';
        this.userRoles = Cookies.get('user');


    }
    rolesMatched = () => {
        if (this.allowedRoles === this.userRoles)
            return true
        else
            return false

    }

    state = {
        initialData: [],
        loading: false,
        data: []
    }

    pera = []
    renderYearlyChart = ''
    renderMonthlyChart = ''
    componentWillMount() {
        axios.get("api/Statistika").then((response) => {


            this.setState({
                initialData: response.data,
                loading: true

            });
            this.state.data = Object.keys(this.state.initialData).map(key => ({
                ...this.state.initialData[key],
                id: key
            }));

            console.log("caos");
            console.log(this.state.data);
            this.renderYearlyChart = (
                <LineChart width={600} height={300} data={this.state.data} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                    <Line type="monotone" dataKey="totalYearIncome" stroke="#8884d8" />
                    <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                    <XAxis dataKey="godina" />
                    <YAxis />
                </LineChart>
            );
            this.renderMonthlyChart = (this.state.data.map(item =>
                <div>
                    <LineChart width={600} height={300} data={item.months} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                        <Line type="monotone" dataKey="totalMonthIncome" stroke="#8884d8" />
                        <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                        <XAxis dataKey="mesec" />
                        <YAxis />
                    </LineChart>
                    <h5 className="mb-3"><i>Godina: {item.godina}  </i></h5>
                </div>
            ));




        });
    }

    componentDidMount() {
        axios.get("api/Statistika").then((response) => {


            this.setState({
                initialData: response.data,
                loading: true

            });
            this.state.data = Object.keys(this.state.initialData).map(key => ({
                ...this.state.initialData[key],
                id: key
            }));

            console.log("caos");
            console.log(this.state.data);
            this.renderYearlyChart = (
                <LineChart width={600} height={300} data={this.state.data} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                    <Line type="monotone" dataKey="totalYearIncome" stroke="#8884d8" />
                    <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                    <XAxis dataKey="godina" />
                    <YAxis />
                </LineChart>
            );
            this.renderMonthlyChart = (this.state.data.map(item =>
                <div>

                    <LineChart width={600} height={300} data={item.months} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                        <Line type="monotone" dataKey="totalMonthIncome" stroke="#8884d8" />
                        <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                        <XAxis dataKey="mesec" />
                        <YAxis />
                    </LineChart>
                    <h5 className="mb-3"><i>Godina: {item.godina}  </i></h5>
                </div>
            ));
        });
    }


    render() {
        let contents = (
            <div>
                <center>
                    <h1>Prikaz statistika celokupnog poslovanja</h1>
                    {this.state.loading ? this.renderYearlyChart : <p>...</p>}
                    {this.state.loading ? this.renderMonthlyChart : <p>...</p>}
                </center>
            </div>
        );
        return (
            this.rolesMatched() ? contents : <NotFound />
        );
    }
}
export default Statistics