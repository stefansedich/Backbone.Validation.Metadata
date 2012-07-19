(function($) {
    _.extend(Backbone.Validation, {
        modelValidationMetadata: {{Metadata}},
        
        metadataValidatorAdapters: {
            'required': function (validator) {
                return {
                    required: true,
                    msg: validator.errorMessage
                };
            },

            'regex': function (validator) {
                return {
                    pattern: validator.validationParameters['pattern'],
                    msg: validator.errorMessage
                };
            },
            
            'range': function (validator) {
                return {
                    range: [validator.validationParameters.min, validator.validationParameters.max],
                    msg: validator.errorMessage
                };
            }
        },
        
        attachMetadataValidators: function(model) {
            if (!model.validationMetadataType || !Backbone.Validation.modelValidationMetadata) {
                return;
            }   

            var modelValidationMetadata = Backbone.Validation.modelValidationMetadata[model.validationMetadataType];
            if (!modelValidationMetadata) {
                return;
            }

            var modelValidators = { };
            
            $.each(modelValidationMetadata, function (i, property) {
                var validators = [];
                
                if (model.validation) {
                    var existing = model.validation[property];
                    if (existing) {
                        validators = validators.concat(existing);
                    }
                }

                $.each(property.validators, function (j, validator) {
                    var adapter = Backbone.Validation.metadataValidatorAdapters[validator.validationType];
                    if(adapter) {
                        var adapted = adapter(validator);

                        validators.push(adapted);
                    }
                });

                modelValidators[property.name] = validators;
            });
            
            model.validation = modelValidators;
        }
    });
})(jQuery);