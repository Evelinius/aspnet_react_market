import React from 'react';
import agent from '../../agent';

export default class AllProducts extends React.Component {
    constructor() {
        super();
        this.state = {
            products: []
        }
    }

    componentDidMount() {
        agent.Products.all().then(products => {
            this.setState({
                products: products.products
            })
        })
    }

    likeOnClick = productId => () => {
        agent.Products.like(productId)
    }

    render() {
        
        return (<div className="container page">
        <div className="row">
            <div className="col-md-10 offset-md-1 col-xs-12">
                {this.state.products.map(product =>
                <div>
                    <div>
                        {product.name}
                    </div>
                    <div> 
                        {product.description}
                    </div>
                    <button onClick={this.likeOnClick(product.productId)}>
                        Добавить в избранное
                    </button>
                </div>
                    )}
            </div>
        </div>
    </div>)
    }
}