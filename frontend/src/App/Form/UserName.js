import React from 'react'

export default function UserName() {
    return (
        <div className="form__row form__row--username">
            <div className="form__label">Enter UserName:</div>
            <input type="text" className="form__value"/>
        </div>
    );
}