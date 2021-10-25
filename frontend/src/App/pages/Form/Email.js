import React from 'react';

export default function Email({ register, errors }) {
    return (
        <>
            <div className="form__row form__row__email">
                <div className="form__label">Enter Email:</div>
                <input
                    type="text"
                    className="form__value"
                    {...register('email', {
                        pattern: { value: /^(\S+)+@(\S+)(\.\S+)$/, message: 'Must be a valid email address' },
                        required: { value: true, message: 'Email is required' },
                    })}
                />
            </div>
            { errors.email && (
                <div className="form__row--errors">
                    {errors.email.message}
                </div>
            )}
        </>
    );
}
