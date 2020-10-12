"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ProjectService = /** @class */ (function () {
    function ProjectService(http) {
        this.http = http;
    }
    ProjectService.prototype.getAllForUserId = function (userId) {
        return this.http.get("/Project/User/" + userId);
    };
    return ProjectService;
}());
exports.ProjectService = ProjectService;
//# sourceMappingURL=ProjectService.js.map