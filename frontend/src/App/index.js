import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import 'normalize.css';
import './index.scss';

import Welcome from './pages/Welcome';
import Confirmation from './pages/Confirmation';
import Form from './pages/Form';
import NotFound from './pages/NotFound';

export default function App() {
    return (
        <Router>
            <Switch>
                <Route path="/" exact>
                    <Welcome />
                </Route>
                <Route path="/booking" exact>
                    <Form />
                </Route>
                <Route path="/confirm/:id" exact>
                    <Confirmation />
                </Route>
                <Route path="*">
                    <NotFound />
                </Route>
            </Switch>
        </Router>
    );
}
