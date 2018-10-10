(function($) {

    $.fn.progressbar = function(options) {
        // build main options before element iteration
        var opts = $.extend({}, {value:0, tooltip:''}, options);

        return this.each(function() {
            //  add the progress DOM strucutre
            $(this).html('<div class="progress_outer"><div class="progress_inner"><div class="progress_indicator"></div></div></div>');
            
            //  if the metadata plug-in is installed, use it to build the options
            var o = $.metadata ? $.extend({}, opts, $(this).metadata()) : opts;
            
            //  location the DOM element that contains
            //  the progress image        
	        $(this).find('.progress_indicator')
	            //  add the tooltip
	            .attr('title', o.tooltip)	        
	            //  and animate the width
	            .animate({width: o.value + '%'}, 'slow');
        });
    };

})(jQuery);