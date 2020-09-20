import React, { useState } from 'react';
import { Layout } from '../shared/layout';
import Calculate from '../shared/calculate';

export const Fibonacci = () => {
    const [value, setValue] = useState('')
    return (
        <Layout pageId="fibonacci">
            <div>
                <label htmlFor="fibonacci_input">Input a number to calculate its fibonacci</label><br/>
                <input type="text" pattern="^0*[0-9]|10$" id="fibonacci_input" placeholder="0~10"
                    onChange={evt => evt.target.validity.valid ? setValue(evt.target.value) : setValue('-1')} />
                <Calculate pageId="fibonacci" inputNum={value}></Calculate>
            </div>
            <p>
                User inputs a number (n) in a textbox, then clicks a button to calculate Fib(n) via a corresponding API call.
                Then the correct result is displayed on the page.
            </p>
        </Layout>
    );
};