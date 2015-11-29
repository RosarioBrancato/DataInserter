using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyAwayInserter.DTO {
	public class ReportMessage {

		public bool Success { get; set; }
		public string Message { get; set; }
		public ReportStatus Status { get; set; }

		public ReportMessage(bool success, string message, ReportStatus status) {
			this.Success = success;
			this.Message = message;
			this.Status = status;
		}

		public MessageBoxIcon GetIconOfStatus() {
			switch(this.Status) {
				case ReportStatus.Info:
					return MessageBoxIcon.Information;

				case ReportStatus.Success:
					return MessageBoxIcon.Information;

				case ReportStatus.Warning:
					return MessageBoxIcon.Warning;

				case ReportStatus.Error:
					return MessageBoxIcon.Error;

				default:
					return MessageBoxIcon.None;
			}
		}

	}

	public enum ReportStatus {
		Info,
		Success,
		Warning,
		Error
	}
}
