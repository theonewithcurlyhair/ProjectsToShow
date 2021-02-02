<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Job Summary : ${vm.getJob().getId()}</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
        <style>
            .table .thead-dark th {
                color: #fff;
                background-color: blueviolet;
                border-color: #FF8888;
            }
        </style>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Job</h1>
        <section id="cover" class="min-vh-100 form-row justify-content-md-center">
            <div id="cover-caption">
                <table class='table'>
                    <caption>Job Details</caption>
                    <thead>
                        <tr>
                            <th>Job Description</th>
                            <th>Client Name</th>
                            <th>Start Date & Time</th>
                            <th>End Date & Time</th>
                            <th>Team</th>
                        </tr>
                    </thead>
                    <tr>
                        <td>${vmJob.getJob().getDescription()}</td>
                        <td>${vmJob.getJob().getClientName()}</td>
                        <td>${vmJob.getJob().getStartString()}</td>
                        <td>${vmJob.getJob().getEndString()}</td>
                        <td>${vmTeam.getTeam().getTeam().getName()}</td>
                    </tr>
                </table>
                <table class='table'>
                    <caption>Job Tasks</caption>
                    <thead>
                        <tr>
                            <th>Operating Cost</th>
                            <th>Operating Revenue</th>
                            <th>Task ID</th>
                        </tr>
                    </thead>
                    <c:forEach items="${vmJobTasks.getTasks()}" var="t">
                        <tr>
                            <td>${t.getOperatingCost()}</td>
                            <td>${t.getOperatingRevenue()}</td>
                            <td>${t.getId()}</td>
                        </tr>
                    </c:forEach>
                </table>
                    <form method="post">
                        <input hidden name="jobId" value="${vmJob.getJob().getId()}"/>
                        <button type="submit" value="delete" name="action">Delete</button>
                    </form>
            </div>
        </section>

        <%@include file="WEB-INF/jspf/footer.jspf" %>
    </body>
</html>