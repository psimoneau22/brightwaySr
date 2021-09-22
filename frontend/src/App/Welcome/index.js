import React from "react";
import { Link } from "react-router-dom";
import "./index.scss";

export default function Welcome() {
    return (
        <div className="welcome">
            <p>Welcome to the Brightway Travel Application</p>
            <p>To begin booking your trip, click 'Next'</p>
            <div>
                <Link to="/book">Next</Link>
            </div>
        </div>
    )
}