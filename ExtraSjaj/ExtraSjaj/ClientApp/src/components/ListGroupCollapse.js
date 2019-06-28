import React from 'react';
import { ListGroupItem, Collapse } from 'reactstrap';
import ListSubheader from '@material-ui/core/ListSubheader';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import StarBorder from '@material-ui/icons/StarBorder';
import CheckCircle from '@material-ui/icons/CheckCircle';
import Block from '@material-ui/icons/Block';

class ListGroupCollapse extends React.Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            collapse: false,
            Racun: this.props.racun
        };
    }
    componentWillMount() {
        this.setState({
            Racun: this.props.racun
        })
    }

    toggle() {
        this.setState({ collapse: !this.state.collapse });

    }

    render() {

        if (this.state.Racun)
            return (
                <ListGroupItem>
                    <div>

                        <List
                            component="nav"
                            aria-labelledby="nested-list-subheader"
                            subheader={
                                <ListSubheader component="div" id="nested-list-subheader">

                                </ListSubheader>
                            }
                        >
                            <ListItem button onClick={this.toggle.bind(this)}>
                                <ListItemIcon>
                                    {this.state.Racun.placen ? <CheckCircle color="primary" /> : <Block color="secondary" />}
                                </ListItemIcon>


                                <ListItemText primary={this.state.Racun.vrijednost +" €"}  /> 
                                <ListItemText primary={this.state.Racun.vrijemeKreiranjaRacuna} ml="2" /> 
                              
                                {this.state.open ? <ExpandLess /> : <ExpandMore />}
                            </ListItem>
                            <Collapse isOpen={this.state.collapse}>
                                <List component="div" disablePadding>
                                    <ListItem button >
                                        <ListItemIcon>
                                            <StarBorder />
                                        </ListItemIcon>
                                        <ListItemText primary="Starred" />
                                    </ListItem>
                                </List>
                            </Collapse>
                        </List>
                       

                    </div>
                </ListGroupItem>
            )
        else
            return (

                <p>?</p>)
    }
}

export default ListGroupCollapse