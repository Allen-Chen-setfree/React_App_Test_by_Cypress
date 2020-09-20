import React, { useState } from 'react';
import { Layout } from '../shared/layout';
import Calculate from '../shared/calculate'

export const RandomSquare = () => {
    const [value, setValue] = useState('')
    return (
        <Layout pageId="randomSquare">
            <div>
                <label htmlFor="randomSquare_input">Input a number to calculate square of a random smaller Integer</label><br />
                <input type="number" id="randomSquare_input"
                    onChange={event => setValue(event.target.value)} />
                <Calculate pageId="random-Square" inputNum={value}></Calculate>
            </div>
            <p>
                User inputs a number (n) in a textbox, then clicks a button to calculate Fib(n) via a corresponding API call.
                Then the correct result is displayed on the page.
            </p>
        </Layout>
    );
};