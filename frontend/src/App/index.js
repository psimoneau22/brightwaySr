import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import 'normalize.css'
import './index.scss'

import Welcome from './Welcome';
import Confirmation from './Confirmation';

import Form from './Form';

export default function App() {
    return (
        <Router>
            <Switch>
                <Route path="/" exact>
                    <Welcome />
                </Route>
                <Route path="/book">
                    <Form />
                </Route>
                <Route path="/confirm">
                    <Confirmation />
                </Route>
            </Switch>
        </Router>
    );
}