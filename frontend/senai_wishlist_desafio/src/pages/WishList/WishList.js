import React, { Component } from 'react';
import '../../assets/css/Default.css';
import '../../assets/css/WishList.css';
import Header from '../../assets/components/Header';
import Footer from '../../assets/components/Footer';


class WishList extends Component{
    
    constructor(){
        super();
        this.state={
            list: [],
            Desejo: ""
        }
        this.BuscarDesejos = this.BuscarDesejos.bind(this);
    }

    BuscarDesejos(){
        fetch('http://localhost:5000/api/Desejos')
        .then(resposta => resposta.json())
        .then(data => this.setState({list: data}))
        .catch(erro => console.error(erro))
    }

    Att(event){
        this.setState({descricao: event.target.value});
    }

    cadastrarDesejo(event){
        event.preventDefault()

        fetch('http://localhost:5000/api/Desejos', {
            method: 'POST',
            body: JSON.stringify({Desejo: this.state.Desejo}),
            headers: {
                "Content-Type" : "application/json"
            }
        })
        .then(resposta => resposta.json())
        .then(this.BuscarDesejos())
        .catch((erro) => console.error(erro))
    };

    


    render(){
        return(
            <div>
                <Header />
                <div class="structure">
                    <section class="escopo">
                        <span>Visualizar:</span>
                        <input type="checkbox" name="Todos" id="" />
                        <span>Todos</span>
                        <input type="checkbox" name="Seus" />
                        <span>Seus</span>
                    </section>
                    <table class="Desejos">
                        <tbody>
                            {
                                this.state.list.map(function(desejo){
                                    return(
                                        <tr key={desejo.descricao}>
                                            <td>{desejo.descricao}</td>
                                        </tr>
                                    )
                                })}
                        </tbody>
                    </table>
                    <form onSubmit={this.cadastrarDesejo.bind(this)}>
                        <input type="text" 
                        value = {this.state.descricao}
                        onChange = {this.Att.bind(this)}
                        ></input>
                        <button>DESEJOO!</button>
                    </form>
                </div>
                <Footer />
            </div>
        )
    }
}
export default WishList;