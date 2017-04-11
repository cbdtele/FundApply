
var stretchers = $$('div.accordion');
stretchers.each(function(item){
	item.setStyles({'height': '0', 'overflow': 'hidden'});
});

window.onload = function(){ //safari cannot get style if window isnt fully loaded
	
	var togglers = $$('h3.toggler');
	
	var bgFx = [];
	
	togglers.each(function(toggler, i){
		toggler.defaultColor = toggler.getStyle('background-color');
		
		//fx creation
		bgFx[i] = new Fx.Color(toggler, 'background-color', {wait: false});
	});

	var myAccordion = new Fx.Accordion(togglers, stretchers, { opacity: false, start: false, transition: Fx.Transitions.quadOut,
		
		onActive: function(toggler, i){
			bgFx[i].toColor('#f4f4f4');
			//toggler.getFirst().setStyle('color', '#000');
			toggler.getFirst().setStyle('text-decoration', 'none');
			toggler.getFirst().parentNode.setStyle('border-bottom-color', '#f4f4f4');
			toggler.getFirst().parentNode.setStyle('padding-bottom', '5px');

			// fix top and bottom images accordingly
			$('top_round').className = (i != 0) ? "top_dark" : "top_light";
			$('bottom_round').className = (i != 4) ? "bottom_dark" : "bottom_light";
			
		},
		
		onBackground: function(toggler, i){
			bgFx[i].clearTimer();

			if(i != 4) {
				toggler.getFirst().parentNode.setStyle('padding-bottom', '11px'); // reset styles
				toggler.getFirst().parentNode.setStyle('border-bottom-color', '#fff');
			}
			else {
				toggler.getFirst().parentNode.setStyle('padding-bottom', '5px');
				toggler.getFirst().parentNode.setStyle('border-bottom-color', '#efefef');
			}
			
			toggler.setStyle('background-color', toggler.defaultColor);
			toggler.getFirst().setStyle('text-decoration', 'none');
			//toggler.getFirst().setStyle('color', '#666');
		}
		
	});
	
	//anchors
	function checkHash(){
		var found = false;
		$$('h3.toggler a').each(function(link, i){
			if (window.location.hash.test(link.hash)){
				myAccordion.showThisHideOpen(i);
				found = true;
			}
		});
		return found;
	}

	if (!checkHash()) myAccordion.showThisHideOpen(0);

};

try {
	Window.disableImageCache();
}catch(e){}