import React, { useEffect } from 'react'
import './index.scss';
import Destination from './Destination';
import Username from './Username';
import Email from './Email';
import Duration from './Duration';
import Submit from './Submit';

export default function Form() {

    console.log('rendForm');
    return (
        <form className="form">
            <Destination/>
            <Username />
            <Email />
            <Duration />
            <Submit />
        </form>
    );
}