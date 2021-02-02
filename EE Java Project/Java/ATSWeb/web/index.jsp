<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <title>Index</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>

        <h1>Welcome to our ATS Project</h1>
        <h2>Index Page</h2>
        
        <p><b>On Call Team name:</b> ${onCallTeam.getTeam().getName()}</p>
        <p><b>With Employees assigned:</b></p>
        <ol>
            <c:forEach items="${onCallTeam.getTeamsEmployee()}" var="emp">
                <li>${emp.getName()}</li>
            </c:forEach>
        </ol>
        
        <p>Today we have ${todaysJobsCount} of jobs</p>
        
        <canvas id="currentYear"></canvas>
        <p>Current year sum for jobs revenue is: ${CurrYearSumRev}</p>
        <p>Current year sum for jobs cost is: ${CurrYearSumCost}</p>
        
        
        <canvas id="previousYear"></canvas>
        <p>Previous year sum for jobs revenue is: ${PrevYearSumRev}</p>
        <p>Previous year sum for jobs cost is: ${PrevYearCost}</p>
    
    <%@include file="WEB-INF/jspf/footer.jspf" %>

    <!-- Stick script at the end of the body -->
    <script src="https://cdn.rawgit.com/nizarmah/calendar-javascript-lib/master/calendarorganizer.min.js"></script>
    <script>

        var ctx = document.getElementById('currentYear').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'line',

            // The data for our dataset
            data: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [{
                        label: 'Current year 2020',
                        backgroundColor: 'rgb(255, 99, 132)',
                        borderColor: 'rgb(255, 99, 132)',
                        data: ${CurrentYearRevenue}
                    }]
            },

            // Configuration options go here
            options: {}
        });

        var ctx = document.getElementById('previousYear').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'line',

            // The data for our dataset
            data: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [{
                        label: 'Previous Year 2019',
                        backgroundColor: 'rgb(255, 99, 132)',
                        borderColor: 'rgb(255, 99, 132)',
                        data: ${PrevYearRevenue}
                    }]
            },

            // Configuration options go here
            options: {}
        });
    </script>
</body>
</html>


