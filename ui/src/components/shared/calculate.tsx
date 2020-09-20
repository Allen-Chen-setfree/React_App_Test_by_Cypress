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
        console.log(this.props.inputNum)
        if ((this.props.inputNum === "-1") || (this.props.inputNum === "")) {
            console.log("test")
            this.setState({ result: "Not Support" })
        } else {
        axios.get('/api/math/' + this.props.pageId + '/' + this.props.inputNum)
            .then(response => {
               this.setState({ result: response.data.result });
            })
            .catch(() => {
                this.setState({ result: "Not Support" });
            }) 
        }
        
    }


    render() {

        return (
            <>
                <br/><button onClick={this.clickHandler}>Calculate</button>             
                <br /><div id="result"><b>{this.state.result}</b></div>          
            </>
            )
    }
}

export default Calculate;
