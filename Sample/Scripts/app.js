var Note = Backbone.Model.extend({
    validationMetadataType: 'note',
    
    defaults: {
        name: '',
        created: ''
    },

    initialize: function () {
        Backbone.Validation.attachMetadataValidators(this);
    }
});

var View = Backbone.View.extend({
    el: $(".container"),
    
    events: {
        'click a.save': 'save'
    },
    
    initialize: function () {
        Backbone.Validation.bind(this);
    },

    save: function () {
        var data = {
            'name': this.$el.find('input[name=name]').val(),
            'created': this.$el.find('input[name=created]').val(),
            'age': this.$el.find('input[name=age]').val()
        };

        if (!this.model.set(data)) {
            return;
        }

        alert("Data is valid saving...");
    }
});

var view = new View({
    model: new Note()
});