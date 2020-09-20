import React, { useState } from 'react';
import { Layout } from '../shared/layout';
import Calculate from '../shared/calculate';

export const Fibonacci = () => {
    const [value, setValue] = useState('')
    return (
        <Layout pageId="fibonacci">
            <p>
                <label htmlFor="fibonacci_input">Input a number to calculate its fibonacci</label><br />
                <input type="number" id="fibonacci_input" placeholder="0~10"
                    onChange={event => setValue(event.target.value)} />
                <Calculate pageId="fibonacci" inputNum={value}></Calculate>
            </p>
            <p>
                User inputs a number (n) in a textbox, then clicks a button to calculate Fib(n) via a corresponding API call.
                Then the correct result is displayed on the page.
            </p>
        </Layout>
    );
};