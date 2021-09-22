import React, { useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { fetchCountries } from '../../features/countries';

export default function Destination() {
    const countries = useSelector(state => state.countries);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(fetchCountries());
    }, []);

    console.log('rendDest');
    return (
        <div className="form__row form__row--destination">
            <div className="form__label">Select Destination:</div>
            <select className="form__value" disabled={countries.status === 'pending'}>
                {countries.data.map(d => <option key={d.id}>{d.name}</option>)}
            </select>
        </div>
    );
}