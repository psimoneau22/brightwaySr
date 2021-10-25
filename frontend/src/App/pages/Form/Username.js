import React from 'react';

export default function Username({ register, errors }) {
    return (
        <>
            <div className="form__row form__row__username">
                <div className="form__label">Enter Username:</div>
                <input
                    type="text"
                    className="form__value"
                    {...register('username', {
                        minLength: { value: 5, message: 'Username must be longer than 5 characters' },
                        required: { value: true, message: 'Username is required' },
                    })}
                />
            </div>
            { errors.username && (
                <div className="form__row--errors">
                    {errors.username.message}
                </div>
            )}
        </>
    );
}
