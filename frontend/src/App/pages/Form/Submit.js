import React from 'react';

export default function Submit({ onClear }) {
    return (
        <div className="form__row form__row__submit">
            <input type="submit" className="form__row__submit__submit" />
            <button type="button" onClick={onClear} className="form__row__submit__clear">Clear</button>
        </div>
    );
}
