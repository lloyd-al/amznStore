import React from 'react';
import ReactDOM from 'react-dom'

class ToolTipController extends React.PureComponent {
    constructor(props) {
        super(props)
        this.tooltip = React.createRef()
    }

    static defaultProps = {
        offsetX: 0,
        offsetY: 0,
        detect: "click",
        closeOnClick: true,
        timeOut: null,
        duration: "",
        timing: "",
        properties: [],
        returnState: null,
        id: ""

    }

    state = {
        divStyle: {
            position: "absolute",
            top: 0,
            left: 0,
            transitionDuration: this.props.duration,
            transitionTimingFunction: this.props.timing,
            transitionProperty: this.props.properties
        },
        isOpen: false,
        animate: false,
        timeOutID: null,
        tooltipWidth: 0,
        trigger: this.props.triggerClose
    }

    open = () => {
        this.setState({ isOpen: true })
    }

    close = () => {
        this.setState({ isOpen: false })
    }

    componentDidUpdate() {
        setTimeout(() => {
            if (this.state.isOpen) {
                window.addEventListener('click', this.close)
            }
            else {
                window.removeEventListener('click', this.close)
            }
        }, 0)
    }

    render() {
        const { children } = this.props
        const { isOpen, style } = this.state

        const inputChildren = React.Children.map(children, child => {
            if (child.type.displayName === "Select") {
                return React.cloneElement(child, { open: this.open })
            }
            else {
                return (
                    isOpen && ReactDOM.createPortal(
                        <span style={style}>{React.cloneElement(child)}</span>,
                        document.body
                    )
                )
            }
        })
        return inputChildren
    }
}
export default ToolTipController;