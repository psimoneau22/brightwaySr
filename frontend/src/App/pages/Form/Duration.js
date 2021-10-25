import React from 'react';

export default function Duration({ register, errors }) {
    return (
        <>
            <div className="form__row form__row__duration">
                <div className="form__label">Length of Stay (days):</div>
                <input
                    type="number"
                    className="form__value"
                    {...register('duration', {
                        valueAsNumber: true,
                        min: { value: 1, message: 'Duration must be greater than 1 day' },
                        max: { value: 90, message: 'Duration must less than 90 days' },
                        required: { value: true, message: 'Duration is required' },
                    })}
                />
            </div>
            { errors.duration && (
                <div className="form__row--errors">
                    {errors.duration.message}
                </div>
            )}
        </>
    );
}
