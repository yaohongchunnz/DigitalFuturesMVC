function createOption(value) {
    el = document.createElement('option');
    el.value = value;
    el.innerHTML = value;
    el.id = value;
    document.getElementById('district').appendChild(el);
}

document.getElementById('city').addEventListener('click', function () {
    document.getElementById('district').innerHTML = '';
    var e = document.getElementById("city");
    var str = e.options[e.selectedIndex].text;
    if (str == "Wellington") {
        createOption("Lower Hutt");
        createOption("Upper Hutt");
    }   
});