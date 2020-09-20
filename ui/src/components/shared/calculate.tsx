import React, { Component } from 'react';
import axios from 'axios';


interface IProps {
    pageId?: string;
    inputNum?: string;

}

interface IState {
    result?: string;
    errorMsg?: string;
}

class Calculate extends Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
        this.state = {
            result: "",
            errorMsg: ""
        };
    }


    clickHandler = () => {

        axios.get('/api/math/' + this.props.pageId + '/' + this.props.inputNum)
            .then(response => {
               this.setState({ result: response.data.result });
                console.log(response.data.result);

            })
            .catch(error => {
                this.setState({ errorMsg:"error retrieving data" });
            })

    }


    render() {

        return (
            <>
                <br/><button onClick={this.clickHandler}>Calculate</button>             
                <br/><b>{this.state.result}</b>          
            </>
            )
    }
}

export default Calculate;
