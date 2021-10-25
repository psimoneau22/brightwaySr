import React from 'react';
import { Link } from 'react-router-dom';
import './index.scss';

export default function Welcome() {
    return (
        <div className="welcome">
            <p>Welcome to the Brightway Travel Application</p>
            <p>To begin booking your trip, click &aposNext&apos</p>
            <div>
                <Link to="/booking">Next</Link>
            </div>
        </div>
    );
}
