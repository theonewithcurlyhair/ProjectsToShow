<%-- 
    Document   : employee
    Created on : 5-Mar-2020, 8:46:50 PM
    Author     : Mike
--%>
<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Employees</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Employee</h1>
        <section>
            <div id="employeesView">
                <c:set var="errors" value="${ error }" />
                <c:set var="employeesList" value="${ employees }" />
                <form class="form-inline mr-auto" method="POST" id="searchForm">
                    <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search" name="searchInput">
                    <button class="btn btn-dark" type="submit" value="search" name="action" id="search">Search</button>
                </form>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">First name</th>
                            <th scope="col">Last name</th>
                            <th scope="col">Was Deleted (but still in a team)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <c:choose>
                            <c:when test="${ employeesList.size() > 0 }">
                                <c:forEach items="${ employeesList }" var="emp">
                                    <c:if test="${!emp.getIsDeleted()}">
                                        <tr onclick="window.location = '/ATSWeb/employee/${emp.getId()}';">
                                            <td>${emp.getFirstName()}</td>
                                            <td>${emp.getLastName()}</td>
                                        </tr>
                                    </c:if>
                                    <c:if test="${emp.getHasTeam() && emp.getIsDeleted()}">
                                            <td>${emp.getFirstName()}</td>
                                            <td>${emp.getLastName()}</td>
                                            <td>${emp.getDeletedAt()}</td>
                                        </tr>
                                    </c:if>
                                </c:forEach>
                            </c:when>
                            <c:when test="${ employees.size() <= 0 || employees == null}">
                                <tr>
                                    <td colspan="8" style="text-align: center;">No employees were found in the system</td>
                                </tr>
                            </c:when>
                        </c:choose>
                    </tbody>
                </table>
                <div class="mt-5">
                    <c:choose>
                        <c:when test="${ error!=null }">
                            <ul class="alert alert-danger">
                                <c:forEach items="${ error.errors }" var="err">
                                    <li>${ err }</li>
                                    </c:forEach>
                            </ul>
                        </c:when>
                    </c:choose>
                </div>
        </section>
        <%@include file="WEB-INF/jspf/footer.jspf" %>
    </body>
</html>