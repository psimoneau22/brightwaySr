import React from 'react';
import { useForm } from 'react-hook-form';
import { useHistory } from 'react-router-dom';
import './index.scss';
import { submitBooking } from '../../../api/bookingProxy';
import Destination from './Destination';
import Username from './Username';
import Email from './Email';
import Duration from './Duration';
import Submit from './Submit';

export default function Form() {
    const {
        handleSubmit, register, reset, formState: { errors },
    } = useForm();
    const history = useHistory();

    const onSubmit = async (data, event) => {
        event.preventDefault();
        const result = await submitBooking(data);
        history.push(`/confirm/${result.id}`);
    };

    const fieldProps = { register, errors };

    return (
        <form className="form" onSubmit={handleSubmit(onSubmit)}>
            <Destination {...fieldProps} />
            <Username {...fieldProps} />
            <Email {...fieldProps} />
            <Duration {...fieldProps} />
            <Submit onClear={() => reset()} />
        </form>
    );
}
