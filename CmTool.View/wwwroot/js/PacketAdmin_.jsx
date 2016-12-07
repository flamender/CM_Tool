
(function (document) {
    "use strict";

    var stringOptions = ["one", "two", "three", "four", "five", "seven",
      "eight", "nine", "ten"];



  
   
   

    document.addEventListener("DOMContentLoaded", function () {

        React.renderComponent(
            ReactComboBox({ options: stringOptions, defaultValue: "en" }),
            document.getElementById('default')
        );

        


        //disable input example
        var disabled = true;

        var disableableComboBox = React.renderComponent(
            ReactComboBox({ options: stringOptions, defaultValue: "n", disabled: disabled }),
            document.getElementById('disableable')
        );

        document.getElementById('disableToggler').addEventListener('click', function () {
            disabled = !disabled;
            disableableComboBox.setProps({ disabled: disabled });
        });

        //you can provide you own item combonent
        var MyCustomItem = React.createClass({
            displayName: 'MyCustomItem',
            render: function () {
                return (
                    React.DOM.div({ className: "myBest" },
                        React.DOM.b(null, this.props.item)
                    )
                );
            }
        });

        React.renderComponent(
            ReactComboBox({ options: stringOptions }, MyCustomItem(null)),
            document.getElementById('customItem')
        );


        //you can use promises as data source

        var dataSource = function (query) {
            var defer = Q.defer();

            //use query to custom or serverside search
            setTimeout(function () {
                defer.resolve(stringOptions);
            }, 500);

            return defer.promise;
        }

        React.renderComponent(
            ReactComboBox({ source: dataSource }),
            document.getElementById('promiseSource')
        );

        //or even oldstyle callback

        var dataSource = function (query, callback) {
            setTimeout(function () {
                callback(stringOptions);
            }, 500);
        }

        React.renderComponent(
            ReactComboBox({ source: dataSource }),
            document.getElementById('callbackSource')
        );

        //objects array as options
        var optionsArray = [
          { id: 1, name: "one" },
          { id: 2, name: "two" },
          { id: 3, name: "three" }
        ];

        React.renderComponent(
            ReactComboBox({ options: optionsArray, titleField: "name" }),
            document.getElementById('objectsArray')
        );

        //customize input
        React.renderComponent(
            ReactComboBox({ options: stringOptions, customInputClass: "form-control" }),
            document.getElementById('cusomizedInput')
        );



    });

})(window.document);
