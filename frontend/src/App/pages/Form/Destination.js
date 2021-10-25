import React from 'react';
import useCountries from '../../../features/useCountries';

export default function Destination({ register, errors }) {
    const countries = useCountries(state => state.countries);

    return (
        <>
            <div className="form__row form__row__destination">
                <div className="form__label">Select Destination:</div>
                <select
                    className="form__value"
                    disabled={countries.status === 'pending'}
                    {...register('destination', {
                        valueAsNumber: true,
                        min: { value: 0, message: 'Destination is required' },
                    })}
                >
                    <option key={-1} value={-1}>{'<Select a Destination>'}</option>
                    {countries.data.map(d => <option key={d.id} value={d.id}>{d.name}</option>)}
                </select>
            </div>
            { errors.dest && (
                <div className="form__row--errors">
                    {errors.dest.message}
                </div>
            )}
        </>
    );
}
