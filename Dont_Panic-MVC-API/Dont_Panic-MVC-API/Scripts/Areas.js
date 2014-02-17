    function selectRegion(num) {

        var dropRegion = document.getElementById("region");
        var dropDistrict = document.getElementById("district");
        var dropSuburb = document.getElementById("suburb");

        var selected;
        var next;

        switch (num) {
            case 1:
                $(dropDistrict).empty();

                $(dropDistrict).append(
                    $('<option/>', {
                        value: "0",
                        text: "Select your district"
                    }))

                $(dropSuburb).empty();
                $(dropSuburb).append(
                   $('<option/>', {
                       value: "0",
                       text: "Select your Suburb"
                   }))

                //  dropDistrict.appendChild
                //  $(dropSuburb).empty();
                //   $(dropDistrict,"option:first").attr("selected", true);

                selected = dropRegion;
                next = dropDistrict;
                break;
            case 2:
                selected = dropDistrict;
                next = dropSuburb;

                $(dropSuburb).empty();
                $(dropSuburb).append(
                   $('<option/>', {
                       value: "0",
                       text: "Select your Suburb"
                   }))

                break;
        }

        var selection = selected.options[selected.selectedIndex].value;

        if (selection == 0) {
            return;
        }

        $.getJSON("/api/DropDown?dropdown=" + num + "&selection=" + selection, function (result) {
            $.each(result, function (i, field) {
                $(next).append(
                $('<option/>', {
                    value: field.Value,
                    text: field.Text
                }))
            });
        });
    }

                     
    function goImgWin(myImage,myWidth,myHeight, origLeft,origTop) {
        myHeight += 24;
        myWidth += 24;
        TheImgWin = window.open(myImage,'image','height=' +
        myHeight + ',width=' + myWidth +
        ',toolbar=no,directories=no,status=no,' +
        'menubar=no,scrollbars=no,resizable=no');
        TheImgWin.resizeTo(myWidth+2,myHeight+30);
        TheImgWin.moveTo(origLeft,origTop);
        TheImgWin.focus();
        alert("Clicked");
    }
                    
