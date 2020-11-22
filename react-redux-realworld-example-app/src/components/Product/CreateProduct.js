import React from 'react';
import agent from '../../agent';

class CreateProduct extends React.Component {
    constructor() {
        super();
        this.state = {
            name: '',
            description: ''
        }
        this.submitForm = ev => {
            ev.preventDefault();
            const product = {
                name: this.state.name,
                description: this.state.description
            };

            const promise = agent.Products.create(product);
        }
    }

    changeName = event => {
        this.setState({
            name: event.target.value
        })
    }

    changeDescription = event => {
        this.setState({
            description: event.target.value
        })
    }

    render() {
        return (
            <div className="editor-page">
                <div className="container page">
                    <div className="row">
                        <div className="col-md-10 offset-md-1 col-xs-12">
                            <form>
                                <fieldset>

                                    <fieldset className="form-group">
                                        <input
                                            className="form-control form-control-lg"
                                            type="text"
                                            placeholder="Product Name"
                                            value={this.state.name}
                                            onChange={this.changeName} />
                                    </fieldset>

                                    <fieldset className="form-group">
                                        <input
                                            className="form-control"
                                            type="text"
                                            placeholder="Product description"
                                            value={this.state.description}
                                            onChange={this.changeDescription} />
                                    </fieldset>

                                    <button
                                        className="btn btn-lg pull-xs-right btn-primary"
                                        type="button"
                                        onClick={this.submitForm}>
                                        Create product
                    </button>

                                </fieldset>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
        )
    }

}

export default CreateProduct;
