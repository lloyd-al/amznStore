import React from 'react'
import ReactDOM from 'react-dom'

class Select extends React.Component {
    static displayName = "Select"

    constructor(props) {
        super(props)
        this.selector = React.createRef()
    }

    getPos = (left, top, height) => {
        this.setState(prevState => ({ style: { ...prevState.style, left, top: top + height } }))
    }

    render() {
        const { children, open } = this.props

        return React.cloneElement(children, { onClick: open })
    }
}

export default Select