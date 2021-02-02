
<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Jobs</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">List Jobs</h1>
        
        <!-- List tasks in table -->
        <c:set var="jobsCount" value="${ vm.getJobs().size() }" />
        <c:choose>
            <c:when test="${jobsCount > 0}">               
            <!--Show when my tasks are greater than zero -->
            <table class="table table-striped">
                    <tr>   
                        <th>
                            Description
                        </th>
                        <th>
                            Client Name
                        </th>  
                    </tr>
                    <!--Iterate through the tasks -->
                    <c:forEach items="${vm.getJobs()}" var="job">                       
                        <tr>
                            <td><a href="job/${job.id}">${job.getDescription()}</a></td>
                            <td>${job.getClientName()}</td>    
                        </tr>
                    </c:forEach>                   
                </table>
            </c:when>
            <c:otherwise>
                <h4 style="text-align:center">No Jobs have been added to the DB</h4>
            </c:otherwise>
        </c:choose>
        

    <%@include file="WEB-INF/jspf/footer.jspf" %>
</body>
</html>