import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import './index.css';
import App from './pages/Home/App';
import NotFound from './pages/NotFound/NotFound';
import WishList from './pages/WishList/WishList';
import NotRegistered from './pages/NotRegistered/NotRegistered';
import Login from './pages/Login/Login';

import * as serviceWorker from './serviceWorker';

const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path="/" component={App}></Route>
                <Route path="/Login" component={Login}></Route>
                <Route path="/Desejos" component={WishList}></Route>
                <Route component={NotFound}></Route>
            </Switch>
        </div>
    </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
