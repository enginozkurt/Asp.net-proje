<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="maps.aspx.cs" Inherits="WebApplication15.admin.WebForm6" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script language="javascript" type="text/javascript">

        var map;
        var geocoder;
        function InitializeMap() {

            var latlng = new google.maps.LatLng(-34.397, 150.644);
            var myOptions =
        {
            zoom:14,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true
        };
            map = new google.maps.Map(document.getElementById("map"), myOptions);
        }

        function FindLocaiton() {
            geocoder = new google.maps.Geocoder();
            InitializeMap();

            var address = document.getElementById("addressinput").value;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });

                }
                else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });
            markicons();
        }


        function Button1_onclick() {
            FindLocaiton();
        }

        window.onload = InitializeMap;
        function markicons() {
            InitializeMap();

            var ltlng = [];

            ltlng.push(new google.maps.LatLng(17.22, 78.28));
            ltlng.push(new google.maps.LatLng(13.5, 79.2));
            ltlng.push(new google.maps.LatLng(15.24, 77.16));

            map.setCenter(ltlng[0]);
            for (var i = 0; i <= ltlng.length; i++) {
                marker = new google.maps.Marker({
                    map: map,
                    position: ltlng[i]
                });

                (function (i, marker) {

                    google.maps.event.addListener(marker, 'click', function () {

                        if (!infowindow) {
                            infowindow = new google.maps.InfoWindow();
                        }

                        infowindow.setContent("Message" + i);

                        infowindow.open(map, marker);

                    });

                })(i, marker);

            }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr>
<td>
    <input id="addressinput" type="text" style="width: 447px" />   
</td>
<td>
    <input id="Button1" type="button" value="Find" onclick="return Button1_onclick()" /></td>
</tr>
<tr>
<td colspan ="2">
<div id ="map" style="height: 450px;width:1100px" >
</div>
</td>
</tr>
</table>

</asp:Content>
