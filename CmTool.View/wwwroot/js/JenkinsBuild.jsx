var btn = React.createClass({
    render: function() {
        return <button type="button" onClick={this.onClick}>Click me</button>
    },

    onClick: function(ev) {
        alert('the button was clicked');    
    }
});


