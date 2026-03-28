using LogiTrack.Tracking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogiTrack.Tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly List<GpsData> _gpsHistory = new List<GpsData>
        {
            new GpsData { Id = 1, TruckId = 1, TruckName = "Truck-001", Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow.AddHours(-2), Speed = 65.5 },
            new GpsData { Id = 2, TruckId = 1, TruckName = "Truck-001", Latitude = 40.7200, Longitude = -74.0100, Timestamp = DateTime.UtcNow.AddHours(-1), Speed = 68.2 },
            new GpsData { Id = 3, TruckId = 2, TruckName = "Truck-002", Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow.AddHours(-3), Speed = 72.0 },
            new GpsData { Id = 4, TruckId = 2, TruckName = "Truck-002", Latitude = 34.0600, Longitude = -118.2500, Timestamp = DateTime.UtcNow.AddHours(-1), Speed = 75.5 }
        };

        /// <summary>
        /// Get GPS history - Protected endpoint requiring Manager role
        /// </summary>
        [HttpGet("gps")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetGpsHistory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new
            {
                success = true,
                message = "GPS data retrieved successfully",
                user = new { userId, email = userEmail, role = userRole },
                data = _gpsHistory.OrderByDescending(g => g.Timestamp)
            });
        }

        /// <summary>
        /// Get GPS history for a specific truck - Protected endpoint requiring Manager role
        /// </summary>
        [HttpGet("gps/{truckId}")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetGpsHistoryByTruck(int truckId)
        {
            var truckData = _gpsHistory.Where(g => g.TruckId == truckId).OrderByDescending(g => g.Timestamp).ToList();

            if (!truckData.Any())
            {
                return NotFound(new { success = false, message = $"No GPS data found for truck {truckId}" });
            }

            return Ok(new
            {
                success = true,
                message = $"GPS data for Truck {truckId} retrieved successfully",
                data = truckData
            });
        }

        /// <summary>
        /// Update GPS location (Drivers can do this)
        /// </summary>
        [HttpPost("gps")]
        [Authorize(Roles = "Manager,Driver")]
        public IActionResult UpdateGpsLocation([FromBody] GpsData newData)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            // Only allow drivers and managers to update
            if (userRole != "Driver" && userRole != "Manager")
            {
                return Forbid("Only Drivers and Managers can update GPS data");
            }

            newData.Id = _gpsHistory.Count + 1;
            newData.Timestamp = DateTime.UtcNow;
            _gpsHistory.Add(newData);

            return Created(nameof(GetGpsHistory), new { success = true, message = "GPS location updated", data = newData });
        }

        /// <summary>
        /// Public endpoint for health check (no authentication required)
        /// </summary>
        [HttpGet("health")]
        [AllowAnonymous]
        public IActionResult Health()
        {
            return Ok(new { status = "Tracking Service is running", timestamp = DateTime.UtcNow });
        }
    }
}
