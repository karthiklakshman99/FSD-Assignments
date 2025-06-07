import React from 'react';

class LifeCycleMount extends React.Component {
    constructor(props) {
        super(props);
        this.state = { 
            name: "Alpha",
            contact: 123456789
        }
    }

    render() {
        return(
            <div>
                <h1>Hello {this.props.name}, Contact {this.state.name} on {this.state.contact}</h1>
            </div>
        );
    }

    getContact = (index) => {
        let newContact = [{ 
            name: "Charlie",
            contact: 987654321
        },
        { 
            name: "Zeta",
            contact: 78654567
        },
        { 
            name: "UnMounted",
            contact: 9000000
        }];
        return newContact[index];
    };

    // Define componentDidMount method to change state value with `this.getContact(0)` after 3 seconds (3000 ms)
    componentDidMount() {
        setTimeout(() => {
            const contact = this.getContact(0);
            this.setState({
                name: contact.name,
                contact: contact.contact
            });
        }, 3000);
    }
    

    // Define componentDidUpdate method to change state value with `this.getContact(1)` after 3 seconds (3000 ms)
    componentDidUpdate(prevProps, prevState) {
        if (prevState.name !== this.state.name) {
            setTimeout(() => {
                const contact = this.getContact(1);
                this.setState({
                    name: contact.name,
                    contact: contact.contact
                });
            }, 3000);
        }
    }

    // Define componentWillUnmount method to change state value with `this.getContact(2)` after 3 seconds (3000 ms)
    componentWillUnmount() {
        setTimeout(() => {
            const contact = this.getContact(2);
            this.setState({
                name: contact.name,
                contact: contact.contact
            });
        }, 3000);
    }
}

export default LifeCycleMount;
