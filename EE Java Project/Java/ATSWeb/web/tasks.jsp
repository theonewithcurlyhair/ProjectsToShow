
<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Task</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">List Tasks</h1>
        
        <!-- List tasks in table -->
        <c:set var="tasksCount" value="${ vm.size() }" />
        <c:choose>
            <c:when test="${tasksCount > 0}">               
            <!--Show when my tasks are greater than zero -->
            <table class="table table-striped">
                    <tr>
                        <th>
                            Name
                        </th>     
                        <th>
                            Description
                        </th>
                    </tr>
                    <!--Iterate through the tasks -->
                    <c:forEach items="${vm}" var="task">                       
                        <tr>
                            <td><a href="task/${task.id}">${task.getName()}</a></td>
                            <td>${task.getDescription()}</td>    
                        </tr>
                    </c:forEach>                   
                </table>
            </c:when>
            <c:otherwise>
                <h4 style="text-align:center">No Tasks have been added to the DB</h4>
            </c:otherwise>
        </c:choose>
        

    <%@include file="WEB-INF/jspf/footer.jspf" %>
</body>
</html>