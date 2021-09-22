import React from 'react'

export default function Username() {
    return (
        <div className="form__row form__row--username">
            <div className="form__label">Enter Username:</div>
            <input type="text" className="form__value"/>
        </div>
    );
}