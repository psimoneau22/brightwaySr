import React from 'react'

export default function Duration() {
    return (
        <div className="form__row form__row--duration">
            <div className="form__label">Length of Stay (days):</div>
            <input type="number" min="1" max="90" className="form__value"/>
        </div>
    );
}